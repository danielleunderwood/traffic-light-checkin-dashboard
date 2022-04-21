# Traffic Light Checkin Dashboard
## Run
    docker build -f trafficlightcheckindashboard/Dockerfile --tag dashboard .
    docker build -f api/Dockerfile --tag api .
    docker-compose up
