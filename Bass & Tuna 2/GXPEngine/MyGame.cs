using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;   // System.Drawing contains drawing tools such as Color definitionsss
public class MyGame : Game
{
	Sound ping;
	Sound fail;
	Sound fishingRodThrownSound;


	ScoreHUD scoreHUD;
	PercentageHUD percentageHUD;
	TimerHUD timerHUD;
	LevelFinishedHUD levelFinishedHUD;
	StartButton startbutton;
	Background background;
	scoreBG scorebg;
	Fish fish;
	FishingRod fishingRod;
	Hooks hooksHUD;
	Tutorial tutorial;
	
	int tile = 0;
	int percentage = 100;
	int timer = 10;
	int startTime;
	int score = 0;
	int cdTime = 0;
	int maxTile = 10;
	int yMusicObject = 0;
	int tilesLeft;
	int hooks = 3;

	int trash = 0;
	int smallFish = 0;
	int mediumFish = 0;
	int bigFish = 0;
	int luckyFish = 0;

	float goodTiles = 0;

	bool coolDown = true;
	bool levelStarted = false;
	bool levelEnded = false;
	bool gameStarted = false;
	bool cdTimerStarted = false;
	bool fishCaught = false;
	bool gameOver = false;
	bool tickSound = false;
	bool tutorialShown = false;
	

	MusicObject[] musicObject = new MusicObject[500];
	public MyGame() : base(Settings.Width, Settings.Height, true)     // Create a window that's 800x600 and NOT fullscreen
	{
		Settings.Load();
		timer = Settings.startTime;
		maxTile = Settings.tiles;

		ping = new Sound("ping.wav", false, false);
		fail = new Sound("ArrowBad.wav", false, false);
		fishingRodThrownSound = new Sound("RodThrown.wav", false, false);



		startbutton = new StartButton();
		AddChild(startbutton);
		
		
	}

	// For every game object, Update is called every frame, by the engine:
	void Update()
	{
		if(tutorialShown == false && Input.GetKey(Key.S)) //start
		{
			startbutton.deleteStartButton();
			tutorial = new Tutorial();
			AddChild(tutorial);
			tutorialShown = true;
		}

        if (gameStarted == false && Input.GetKey(Key.P) && tutorialShown==true) //tutorial
		{
			tutorial.Destroy();
			gameStart();
			gameStarted = true;
		}


        if (gameStarted) 
		{
			gameStarting();
		}
		

		if(levelEnded && fishCaught == false ) //ending level by catching smth
		{

			levelEnding();
			
		}

		newLevel();


		//Console.WriteLine(hooks);
	}

	void gameStarting() 
	{
		inputs();
		coolDowner();
		levelTimer();

		if (tile == maxTile) //check if there are no more tiles
		{
			levelEnded = true;
			tile = 0;
			if (percentage >= 80) //hook changes here 
			{
				
				if (hooks + 1 <= 4)
				{
					hooks++;

				}
			}
            
		}
	}
	void levelEnding() 
	{
		tile = 0;

		tickSound = false;
		fishingRod.DeleteRod();
		scorebg = new scoreBG();
		AddChild(scorebg);
		hooks--;

		for (int i = 0; i < maxTile; i++)
		{
			if (musicObject[i] != null)
			{
				musicObject[i].Destroy();
			}
		}
		

		background.DeleteBG();

		scoreHUD.Destroy();

		percentageHUD.Destroy();

		timerHUD.Destroy();

		hooksHUD.Destroy();

		fishCaught = true;
		fish = new Fish();
		AddChild(fish);
		checkFish(fish.GetFish());


		

		if (100 <= percentage + timer)
		{
			percentage = 100;
		}
		else
		{
			percentage = percentage + (int)(timer/2);
		}
		score = score + fish.GetFishScore();
		if (hooks <= 0)
		{
			levelFinishedHUD = new LevelFinishedHUD(true);
			gameOver = true;
		}
		else
		{
			levelFinishedHUD = new LevelFinishedHUD(false);
		}
		AddChild(levelFinishedHUD);
		levelFinishedHUD.SetXY(width / 2 - levelFinishedHUD.width / 2, height / 2 - levelFinishedHUD.height / 2);
		levelStarted = false;

	}

	void checkFish(int x) 
	{
		if(x == 1) 
		{
			trash++;

		}
		if (x == 2)
		{
			smallFish++;
		}
		if (x == 3)
		{
			mediumFish++;
		}
		if (x == 4)
		{
			bigFish++;
		}
		if (x == 5)
		{
			luckyFish++;
		}
	}

	void huds() 
	{
		scoreHUD = new ScoreHUD();
		AddChild(scoreHUD);
			scoreHUD.SetXY(0, 670);

		percentageHUD = new PercentageHUD();
		AddChild(percentageHUD);
		percentageHUD.SetXY(1170, 0);

		timerHUD = new TimerHUD();
		AddChild(timerHUD);
		timerHUD.SetXY(550, 670);

		hooksHUD = new Hooks();
		AddChild(hooksHUD);
	}
	void gameStart() 
	{
		huds();


		tileSpawner();
		

		coolDown = false;
	}
	void inputs() 
	{
		if (coolDown && levelEnded == false)
		{
			levelStarted = true;
			if (Input.GetKey(Key.A))
			{

				check(1);

			}
			if (Input.GetKey(Key.W))
			{

				check(2);

			}
			if (Input.GetKey(Key.R))
			{
				check(3);
			}
			if (Input.GetKey(Key.S))
			{

				check(4);

			}
			if (Input.GetKey(Key.D))
			{

				check(5);

			}
		}
	}
	void check(int x) 
	{
		if (musicObject[tile] != null)
		{
			if (musicObject[tile].pos == x)
			{
				ping.Play();
				goodTiles++;
				score = score + 10;
			}
			else
			{
				fail.Play();
				if (score >= 10)
				{
					score = score - 10;
				}
			}
		}
		percentage = (int) ((goodTiles / (tile+1)) * 100);

		lowering();
	}
	void coolDowner() 
	{
		
		if (cdTimerStarted == false)
		{
			cdTime = Time.time;
		}
		if (coolDown == false) //start timer
		{
			cdTimerStarted = true;

			if (Time.time - cdTime > 150) //timer ends
			{
				coolDown = true;
				cdTimerStarted = false;
			}
		}
	}
	void lowering() 
	{
		if (musicObject[tile] != null)
		{
			musicObject[tile].LateDestroy();
			tile++;


			for (int i = 0; i < maxTile; i++)
			{
				if (musicObject[i] != null)
				{
					musicObject[i].Movement();
				}
			}
			coolDown = false;


		}
	}
	void tileSpawner() 
	{
		background = new Background();
		AddChild(background);

		huds();
		//throw fishing rod

		fishingRod = new FishingRod();
		if(fishingRod!= null) 
		{
			AddChild(fishingRod);
		}

		fishingRodThrownSound.Play();

		yMusicObject = 500;
		for (int i = 0; i < maxTile; i++)
		{
			musicObject[i] = new MusicObject();
			musicObject[i].y = yMusicObject;
			AddChild(musicObject[i]);
			yMusicObject -= 100;
			//Console.WriteLine("tile spawned at y = " + yMusicObject);
		}
	}

	void newLevel() 
	{
		if (Input.GetKey(Key.P) && levelEnded && gameOver==false && fish.AnimationDone())
		{
			maxTile = maxTile + Settings.tileDifference;
			levelLoad();
			
			//timer = timer - Settings.timeDifference; 
			goodTiles = 0;
			
			
		}
		if(Input.GetKey(Key.P) && levelEnded && gameOver && fish.AnimationDone())  //GAME RESTART
		{
			//levelLoad();

			trash = 0;
			smallFish = 0;
			mediumFish = 0;	
			bigFish = 0;
			luckyFish = 0;
			score = 0;
			hooks = 3;
			goodTiles = 0;

			//timer = timer - Settings.timeDifference; 
			maxTile = Settings.tiles;
			gameOver = false;
		}
	}

	void levelLoad() 
	{
		fish.Destroy();


		levelFinishedHUD.Destroy();
		scorebg.Destroy();
		
		
		levelEnded = false;
		fishCaught = false;
		
		startTime = Time.time;
		percentage = 0;
		timer = Settings.startTime;
		tileSpawner();
		coolDown = false;
		gameStarted = true;
		levelStarted = true;

		
	}

	void levelTimer() 
	{
		//startTime = Time.time; is called only once before starting the timer
		if (levelStarted && gameStarted)
		{
			if (Time.time - startTime >= 1000) // one second passed
			{
				startTime = Time.time;
				timer--;
			}

			if (Time.time - startTime > (timer - 10) * 1000)  // 10 seconds left
			{
				tickSound = true;
			}

			if (Time.time - startTime > timer * 1000) // timer ended
			{
				percentage = 0;
				tilesLeft = maxTile - tile;
				levelEnded = true;
				levelStarted = false;
			}
		}
	}

	public int GetHooks() { return hooks; }
	public int GetPercent() 
	{
		return percentage;
	}
	public int GetScore() 
	{
		return score; 
	}	
	public int GetSeconds() 
	{
		return timer;
	}
	public int GetExtraTime() 
	{
		return timer; 
	}
	public int GetTilesLeft() 
	{
		return tilesLeft; 
	}
	public int GetTrash() { return trash; }
	public int GetSmallFish() { return smallFish; }
	public int GetMediumFish() { return mediumFish; }
	public int GetBigFish() { return bigFish; }
	public int GetLuckyFish() { return luckyFish; }

	public bool GetTickSound() { return tickSound;	}

	static void Main()                          // Main() is the first method that's called when the program is run
	{

		new MyGame().Start();                   // Create a "MyGame" and start it
	}
}