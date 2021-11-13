#!/bin/sh

read -p "Please enter the sql server address (example - 'mariadb' for docker-compose): " sqlServer
read -p "Please enter the sql username (example - 'root'): " sqlUsername
read -p "Please enter the sql password: " sqlPassword
read -p "Please enter the sql database name (example - 'justchooseanydbname'): " sqlDatabase
read -p "Please enter the smtp host address (example -'mail.privateemail.com' for namecheap): " smtpHost
read -p "Please enter the smtp port (example - '465' for namecheap): " smtpPort
read -p "Please enter the smtp username (example 'noreply@example.com'): " smtpUsername
read -p "Please enter the smtp password: " smtpPassword
read -p "Please enter the smtp from name (example - 'Elon Musk'): " smtpFromName
read -p "Please enter the smtp from address (example - 'noreply@example.com'): " smtpFromAddress
read -p "Please enter the discord client id: " discordClientId
read -p "Please enter the discord client secret: " discordClientSecret
parent=$(dirname $(dirname "$0"))
cd "$parent"/secrets
echo "generating secrets..."
echo "$sqlServer" > sql-server
echo "$sqlUsername" > sql-username
echo "$sqlPassword" > sql-password
echo "$sqlDatabase" > sql-database
echo "$smtpHost" > smtp-host
echo "$smtpPort" > smtp-port
echo "$smtpUsername" > smtp-username
echo "$smtpPassword" > smtp-password
echo "$smtpFromName" > smtp-fromname
echo "$smtpFromAddress" > smtp-fromaddress
echo "$discordClientId" > discord-clientid
echo "$discordClientSecret" > discord-clientsecret
echo "secrets generated!"
