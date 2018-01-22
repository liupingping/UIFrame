using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public  class AppLoadManager
{
    public static AppLoadManager appLoadManager;

    public static AppLoadManager instance()
    {

        if (appLoadManager == null)
        {
            appLoadManager = new AppLoadManager();
        }

        return appLoadManager;
    }


    public void Load()
    {
        

    }






}