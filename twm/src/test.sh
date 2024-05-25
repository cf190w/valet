#!/bin/bash

if [ "$1" == "start" ]; then
    # Run xfwm4 --replace && twm
    xfwm4 --replace &
    twm

elif [ "$1" == "stop" ]; then
    # Restart xfwm4
    xfwm4 --replace &

else
    echo "Invalid argument. Usage: ./script.sh [start|stop]"
fi
