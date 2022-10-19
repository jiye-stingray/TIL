public void SpawnDataParce(int stage)
    {
        string filename = "stage" + stage.ToString();


        spawnList.Clear();

        TextAsset textAsset = Resources.Load(filename) as TextAsset;
        StringReader stringReader = new StringReader(textAsset.text);

        while (stringReader != null)
        {

            string line = stringReader.ReadLine();

            if (line == null)
            {
                break;
            }

            Spawn spawn = new Spawn();

            spawn.name = line.Split(',')[0];
            spawn.pos = int.Parse(line.Split(',')[1]);
            spawn.delay = float.Parse(line.Split(',')[2]);

            spawnList.Add(spawn);
        }

        stringReader.Close();

        spawnEnemyCoroutine = StartCoroutine(SpawnEnemy());

    }