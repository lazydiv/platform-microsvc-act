# Platform Microservice Architecture

This repository contains a platform application with a microservice architecture using Kubernetes, RabbitMQ, and .NET.

## Table of Contents

- [Introduction](#introduction)
- [Architecture](#architecture)
- [Setup](#setup)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Deployment](#deployment)
- [Usage](#usage)
  - [Accessing Services](#accessing-services)
  - [Monitoring](#monitoring)
- [Contributing](#contributing)
- [License](#license)

## Introduction

This project demonstrates a microservice architecture deployed on Kubernetes, with RabbitMQ as the message broker and .NET for the services.

## Architecture

- **Kubernetes**: Orchestrates the deployment, scaling, and management of containerized applications.
- **RabbitMQ**: Acts as the message broker for inter-service communication.
- **.NET**: Provides the framework for building the microservices.

## Setup

### Prerequisites

- [Docker](https://www.docker.com/get-started)
- [Kubernetes](https://kubernetes.io/docs/setup/)
- [RabbitMQ](https://www.rabbitmq.com/download.html)
- [.NET SDK](https://dotnet.microsoft.com/download)

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/lazydiv/platform-microsvc-act.git
    cd platform-microsvc-act
    ```

2. Build the Docker images:
    ```sh
    docker-compose build
    ```

3. Deploy to Kubernetes:
    ```sh
    kubectl apply -f k8s/
    ```

## Deployment

Follow the setup instructions to deploy the application to your Kubernetes cluster. Ensure that all services are running correctly by checking the status of pods and services in Kubernetes.

## Usage

### Accessing Services

1. Access the services through the Kubernetes ingress. Configure the ingress to expose the necessary services.

### Monitoring

2. Monitor RabbitMQ queues for inter-service communication. Use RabbitMQ management UI or command-line tools to check the status of queues and messages.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request. For major changes, please open an issue first to discuss what you would like to change.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
