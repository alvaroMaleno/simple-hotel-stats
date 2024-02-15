#!/bin/bash
bash ./apiscripts/installingnetcore.sh 
bash ./webscripts/pythoninstall.sh
bash ./apiscripts/buildandrunhotelapi.sh &
bash ./webscripts/html.sh
wait
exit