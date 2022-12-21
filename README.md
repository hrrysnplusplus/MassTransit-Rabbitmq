# Mass Transit + Rabbitmq = Microservice

## Setup
- Build and run on docker compose

## Ports
- Rabbitmq management portal - localhost:15672 - (user: guest, pw: guest) 
- Alarm Service - localhost:50000

## Mass Transit
I love Mass Transit because it abstracts complex boilerplate rabbitmq/.net code 
into teeny tiny elagant readable code.

## Rabbitmq
Rabbitmq allows services/databases to communicate with one another.
It gives messages a safe place to hide until it is received.

Handling millions of messages per second is what makes message brokers like rabbitmq and kafka,
the GO TO technology for scalable apps and distributed systems.
