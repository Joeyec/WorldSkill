using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendAnswerRequest
{
    public string Token { get; set; }
    public string StudentId { get; set; }
    public string[] Answers { get; set; }
    public int ExerciseId { get; set; }
}

public class SendAnswerResponse
{
    public bool IsSuccess { get; set; }
    public string Errors { get; set; }

}