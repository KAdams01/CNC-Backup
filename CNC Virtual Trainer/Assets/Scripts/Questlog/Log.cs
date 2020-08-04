using System;

public class Log
{
    public LogContent english;
    public LogContent danish;
    public int number;

    public bool isEnglish;

    private bool completed = false;

    public Log(LogContent english, LogContent danish, int number)
    {
        this.english = english;
        this.danish = danish;
        this.number = number;
        isEnglish = false;
    }

    public void complete()
    {
        this.completed = true;
    }

    public bool isCompleted()
    {
        return this.completed;
    }

    public void ChangeLanguageToEnglish()
    {
        isEnglish = true;
    }

    public void ChangeLanguageToDanish()
    {
        isEnglish = false;
    }

}
