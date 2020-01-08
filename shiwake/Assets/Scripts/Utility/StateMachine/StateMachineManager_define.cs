/*
 * @file StateMachineManager_define.cs
 * ステートマシンの種類を記載する定義クラス.
 * @author 山下
 */

using UnityEngine;
using System.Collections;

/// <summary>
///	ステートマシンの種類を記載する定義クラス.
/// </summary>
public enum StateMachineName : int
{
	Test,
	InGame,
	Max,
};

/// <summary>
/// </summary>
public enum InGame1State : int
{
	Initialize = 0,
	StartEffect,
	UserWait,
	ClearCheck,
	MoveEffect,
	ClearEffect,
	FailureEffect,
	End
};

/// <summary>
/// </summary>
public enum InGame3State : int
{
	Initialize = 0,
	StartEffect,
	SpawnFirstButton,
	FirstUserWait,
	CheckPower,
	SpawnSecondButton,
	SecondUserWait,
	ClearEffect,
	FailureEffect,
	End
};

/// <summary>
/// </summary>
public enum InGame4State : int
{
	Initialize = 0,
	StartEffect,
	UserWait,
	UpdateQuestion,
	ClearEffect,
	FailureEffect,
	End
};

/// <summary>
/// </summary>
public enum InGame5State : int
{
	Initialize = 0,
	StartEffect,
	QuestionDisplay,
	UserWait,
	AnswerResult,
	ClearCheck,
	ClearEffect,
	FailureEffect,
	End
};

/// <summary>
/// </summary>
public enum InGame6State : int
{
	Initialize = 0,
	StartEffect,
	QuestionDisplay,
	UserWait,
	AnswerResult,
	ClearCheck,
	ClearEffect,
	End
};

/// <summary>
/// </summary>
public enum InGame7State : int
{
	Initialize = 0,
	StartEffect,
	QuestionDisplay,
	UserWait,
	AnswerResult,
	ClearCheck,
	ClearEffect,
	End
};

/// <summary>
/// </summary>
public enum InGame8State : int
{
	Initialize = 0,
	StartEffect,
	QuestionDisplay,
	UserWait,
	AnswerResult,
	ClearCheck,
	ClearEffect,
	End
};

/// <summary>
/// </summary>
public enum InGame9State : int
{
	Initialize = 0,
	StartEffect,
	QuestionDisplay,
	UserWait,
	AnswerResult,
	ClearCheck,
	ClearEffect,
	End
};

