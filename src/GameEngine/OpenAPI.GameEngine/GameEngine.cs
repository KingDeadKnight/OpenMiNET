﻿using System;
using log4net;
using OpenAPI.GameEngine.Games;
using OpenAPI.Plugins;

namespace OpenAPI.GameEngine
{
    [OpenPluginInfo(Name = "OpenAPI GameEngine", Description = "A free to use Game Engine for OpenAPI",
        Author = "Kenny van Vulpen")]
    public class GameEngine : OpenPlugin
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(GameEngine));

        private OpenApi Host { get; set; }
        public GameManager GameManager { get; set; }
        
        private JoinQuitHandler JoinQuitHandler { get; set; }
        public GameEngine()
        {
            GameManager = new GameManager();
            JoinQuitHandler = new JoinQuitHandler(GameManager);
        }
        
        public override void Enabled(OpenApi api)
        {
            Host = api;
            api.EventDispatcher.RegisterEvents(JoinQuitHandler);
        }

        public override void Disabled(OpenApi api)
        {
            api.EventDispatcher.UnregisterEvents(JoinQuitHandler);
        }
    }
}