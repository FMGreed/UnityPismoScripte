	
	//javni float u kojem je upisan iznos pS (playerSpeed), tj koliko brzo će se naš player kretati 

	public float pS : 10.0;

	void Start()
	
	//playerMovement pišemo pod update umjesto pod start iz razloga što želimo da movement bude konstantan 
	void Update (){
		 playerMovement ();
	}
	



	//void playerMovement je varijabla u kojoj je opisao što trebamo stisnuti da nam se character počne kretati i u kojem smjeru će se kretati 
	void playerMovement (){
		

	//tu je upisano što je potrebno napraviti da kretnja počne 
	if (input.GetKeyDown(Key.Code W));
		
		//ovdje odlučimo po i kojoj koordinatni će se character kretati;i kojom brzinom 
		transform.Translate (pS, 0,0);
	}

    