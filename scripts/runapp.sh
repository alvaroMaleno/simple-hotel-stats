#!/bin/bash
bash ./apiscripts/buildandrunhotelapi.sh &
bash ./webscripts/html.sh
wait
exit