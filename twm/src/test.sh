#!/bin/bash

if [ "$1" == "start" ]; then
    # Save the current session
    xfce4-session-logout --save

    # Kill Xfce4 panel and Plank
    xfce4-panel --quit
    killall plank

    # Introduce a delay of 1 second
    sleep 1

    # Switch to TWM
    xfwm4 --replace && twm
elif [ "$1" == "stop" ]; then
    # Restart the Xfce4 session
    xfce4-session-logout --fast
else
    echo "Invalid argument. Usage: ./script.sh [start|stop]"
fi
