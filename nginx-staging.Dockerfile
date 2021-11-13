FROM ubuntu:20.04
RUN apt-get update -y
RUN apt-get install -y nginx certbot python3-certbot-nginx cron
COPY nginx/nginx-staging.conf .
COPY scripts/nginx-entrypoint-staging.sh .
RUN chmod +x ./nginx-entrypoint-staging.sh
ENTRYPOINT ["./nginx-entrypoint-staging.sh"]
