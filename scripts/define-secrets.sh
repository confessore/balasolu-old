#!/bin/sh

read -p "please enter the sql server address (example - 'mariadb' for docker-compose): " sqlServer
read -p "please enter the sql root password: " sqlPasswordRoot
read -p "please enter the sql username (example - 'root'): " sqlUsername
read -p "please enter the sql password: " sqlPassword
read -p "please enter the sql database name (example - 'justchooseanydbname'): " sqlDatabase
read -p "please enter the smtp host address (example -'mail.gandi.net' for gandi): " smtpHost
read -p "please enter the smtp port (example - '465' for ssl): " smtpPort
read -p "please enter the smtp username (example 'noreply@example.com'): " smtpUsername
read -p "please enter the smtp password: " smtpPassword
read -p "please enter the smtp from name (example - 'azuremyst'): " smtpFromName
read -p "please enter the smtp from address (example - 'noreply@example.com'): " smtpFromAddress
read -p "please enter the twitter key: " twitterKey
read -p "please enter the twitter key secret: " twitterKeySecret
read -p "please enter the twitter bearer token: " twitterBearerToken

if [ "$(dirname $0)" = "." ]
then
    mkdir -p ../secrets
    cd ../secrets
else
    parent=$(dirname $(dirname "$0"))
    mkdir -p "$parent"/secrets
    cd "$parent"/secrets
fi

echo "generating secrets..."
echo "$twitterKey" > twitter-key
echo "$twitterKeySecret" > twitter-keysecret
echo "$twitterBearerToken" > twitter-bearertoken
echo "$sqlServer" > sql-server
echo "$sqlPasswordRoot" > sql-password-root
echo "$sqlUsername" > sql-username
echo "$sqlPassword" > sql-password
echo "$sqlDatabase" > sql-database
echo "$smtpHost" > smtp-host
echo "$smtpPort" > smtp-port
echo "$smtpUsername" > smtp-username
echo "$smtpPassword" > smtp-password
echo "$smtpFromName" > smtp-fromname
echo "$smtpFromAddress" > smtp-fromaddress
echo "secrets generated!"
