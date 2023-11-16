pipeline {
    agent {
        label 'master'
    }
    tools {
        // jdk 'Java20'
        // maven 'Maven3'
        dotnet 'dotnet'
        msbuild 'msbuild'
    }
    stages {
        stage('Cleanup Workspace') {
            steps {
                cleanWs()
            }
        }
        stage('Checkout GitHub Branch') {
            steps {
               git branch: 'refs/heads/main', credentialsId: 'github', url: 'https://github.com/darbeiter/CSharp-Microservices'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}