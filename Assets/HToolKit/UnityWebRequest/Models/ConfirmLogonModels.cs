using System;
public class ConfirmLogonResponse
{

    public int ExamId { get; set; }
    public int[] Exercises { get; set; }
    public string[][] Answers { get; set; }
    public string Token { get; set; }
    public DateTime ExpireTime { get; set; }
}
