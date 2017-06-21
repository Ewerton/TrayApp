# TrayApp
Tray app that runs a Scheduled Task

This app was created for a Stackoverflow question.

This application runs on System Tray and registers a Scheduled Task on Windows.
Every minute, the application calls itself passing the "NOGUI" argument which indicates that some "background" process needs to run.

The issue is that every minute a new Icon is reated in the Tray.
