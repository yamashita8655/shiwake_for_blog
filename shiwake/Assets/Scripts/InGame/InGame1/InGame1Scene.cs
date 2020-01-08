using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame1Scene : SceneBase
{
	// UIアクセス群
	[SerializeField]
	private GameObject CuConveyorObject = null;
	public GameObject ConveyorObject => CuConveyorObject;
	
	[SerializeField]
	private GameObject CuCCFront = null;
	public GameObject CCFront => CuCCFront;
	
	[SerializeField]
	private PalletObjectController[] CuPalletObjectControllers = null;
	public PalletObjectController[] PalletObjectControllers => CuPalletObjectControllers;
	
	[SerializeField]
	private Text CuScoreText = null;
	public Text ScoreText => CuScoreText;

	private readonly float BaggageObjectSpawnTime = 1f;
	//private readonly float BaggageObjectSpawnTime = 50f;
	private float BaggageObjectSpawnTimer = 0f;
	//private float BaggageObjectSpawnTimer = 100f;
	//private List<BaggageObject> BaggageObjectList = new List<BaggageObject>();
	
	// Start is called before the first frame update
	void Start()
	{
		//SoundManager.Instance.PlayBgm(Enum.Bgm.Game);

		// データキャリア
		InGame1DataCarrier.Instance.Initialize();
		InGame1DataCarrier.Instance.Scene = this;

		// ステートマシン
		StateMachineManager.Instance.Init();
		var stm = StateMachineManager.Instance;
		stm.CreateStateMachineMap(StateMachineName.InGame);
		stm.AddState(StateMachineName.InGame, (int)InGame1State.Initialize, new InGame1InitializeState());
		stm.AddState(StateMachineName.InGame, (int)InGame1State.StartEffect, new InGame1StartEffectState());
		stm.AddState(StateMachineName.InGame, (int)InGame1State.UserWait, new InGame1UserWaitState());
		stm.AddState(StateMachineName.InGame, (int)InGame1State.ClearCheck, new InGame1ClearCheckState());
		stm.AddState(StateMachineName.InGame, (int)InGame1State.MoveEffect, new InGame1MoveEffectState());
		stm.AddState(StateMachineName.InGame, (int)InGame1State.ClearEffect, new InGame1ClearEffectState());
		stm.AddState(StateMachineName.InGame, (int)InGame1State.FailureEffect, new InGame1FailureEffectState());
		stm.AddState(StateMachineName.InGame, (int)InGame1State.End, new InGame1EndState());
		
		stm.ChangeState(StateMachineName.InGame, (int)InGame1State.Initialize);
			
		FadeManager.Instance.FadeOut(FadeManager.Type.Mask, 0.5f, null);
	}

	// Update is called once per frame
	void Update()
	{
		StateMachineManager.Instance.Update(StateMachineName.InGame, Time.deltaTime);

		UpdateBaggageObject();
	}

	private void UpdateBaggageObject() {
		SpawnBaggageObject();
		//MoveBaggageObject();
	}
	
	private void SpawnBaggageObject() {
		BaggageObjectSpawnTimer += Time.deltaTime;
		if (BaggageObjectSpawnTimer >= BaggageObjectSpawnTime) {
			BaggageObjectSpawnTimer = 0f;
			GameObject obj = SerializeFieldResourceManager.Instance.GetInGame1BaggageObject();

			obj.transform.SetParent(CuConveyorObject.transform);
			//obj.transform.localPosition = Vector3.zero;
			//obj.transform.localScale = Vector3.one;

			BaggageObject comp = obj.GetComponent<BaggageObject>();
			comp.Initialize(2f, CCFront, 1);
			//BaggageObjectList.Add(comp);
		}
	}

	public void UpdateScoreText() {
		ScoreText.text = InGame1DataCarrier.Instance.CurrentScore.ToString();
	}
	
	//private void MoveBaggageObject() {
	//	for (int i = 0; i < BaggageObjectList.Count; i++) {
	//		BaggageObjectList[i].Move(1f);
	//	}
	//}
}
