#!/bin/sh

if [ ! -f /etc/letsencrypt/options-ssl-nginx.conf ]
then
    nginx
    echo "Generating SSL Certificate..."
    certbot certonly \
        -n \
        --nginx \
        --register-unsafely-without-email \
        --agree-tos \
        -d balasolu.com \
        -d www.balasolu.com
    echo "SSL Certificate Generated!"
    echo "Copying SSL Config..."
    cp /nginx-release.conf /etc/nginx/nginx.conf
    echo "SSL Config Copied!"
    echo "Reloading NGINX..."
    nginx -t && nginx -s reload
    echo "NGINX Reloaded!"
    service nginx stop
else
    echo "Copying SSL Config..."
    cp /nginx-release.conf /etc/nginx/nginx.conf
    echo "SSL Config Copied!"
fi
echo "Scheduling Cron Job..."
echo "0 23 * * * certbot renew --quiet" | crontab -
echo "Cron Job Scheduled!"
nginx -g 'daemon off;'
