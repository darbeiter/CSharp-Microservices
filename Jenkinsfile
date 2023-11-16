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
               git 'https://github.com/darbeiter/CSharp-Microservices'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}