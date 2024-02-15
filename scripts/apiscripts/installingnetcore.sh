#!/bin/bash
echo '----------Getting Packages Ubuntu 20.1------------------------'
echo '----------Getting Packages Ubuntu 20.1------------------------'
echo '----------Getting Packages Ubuntu 20.1------------------------'
echo '----------Getting Packages Ubuntu 20.1------------------------'
echo '----------Getting Packages Ubuntu 20.1------------------------'
wget https://packages.microsoft.com/config/ubuntu/20.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
echo '----------Installing SDK-5 Ubuntu 20.1------------------------'
echo '----------Installing SDK-5 Ubuntu 20.1------------------------'
echo '----------Installing SDK-5 Ubuntu 20.1------------------------'
echo '----------Installing SDK-5 Ubuntu 20.1------------------------'
echo '----------Installing SDK-5 Ubuntu 20.1------------------------'
sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-5.0
echo '----------Installing JustInTime Instance Ubuntu 20.1------------------------'
echo '----------Installing JustInTime Instance Ubuntu 20.1------------------------'
echo '----------Installing JustInTime Instance Ubuntu 20.1------------------------'
echo '----------Installing JustInTime Instance Ubuntu 20.1------------------------'
echo '----------Installing JustInTime Instance Ubuntu 20.1------------------------'
sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y aspnetcore-runtime-5.0
exit