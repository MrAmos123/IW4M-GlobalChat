﻿using SharedLibraryCore;
using SharedLibraryCore.Interfaces;

namespace IW4M_GlobalChat;

public class Plugin : IPlugin
{
    public Plugin()
    {
        Manager = new Manager();
    }

    public static Manager Manager;

    public string Name => "IW4M Global Chat";
    public float Version => 20220710f;
    public string Author => "Amos";

    public Task OnLoadAsync(IManager manager)
    {
        Console.WriteLine("IW4M Global Chat loaded");
        return Task.CompletedTask;
    }

    public Task OnUnloadAsync()
    {
        return Task.CompletedTask;
    }

    public async Task OnEventAsync(GameEvent gameEvent, Server server)
    {
        switch (gameEvent.Type)
        {
            case GameEvent.EventType.Say:
                Manager.SendGlobalChatMessage(gameEvent.Origin, gameEvent.Message);
                break;
        }
    }

    public Task OnTickAsync(Server server)
    {
        return Task.CompletedTask;
    }
}
