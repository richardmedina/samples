#!/bin/bash

# This file will compile maven project at reactapp directory and then
# will be moved to tomcat installed on $TOMCAT_HOME


PROJECT_HOME=./reactapp
TOMCAT_HOME=/Users/richard/apps/tomcat/apache-tomcat-9.0.54


APP_SRC_NAME=reactapp-0.0.1-SNAPSHOT.war
APP_DST_NAME=reactapp.war

sh $TOMCAT_HOME/bin/shutdown.sh
rm $TOMCAT_HOME/webapps/$APP_DST_NAME

cd $PROJECT_HOME 
mvn clean install
cd ..

cp $PROJECT_HOME/target/$APP_SRC_NAME $TOMCAT_HOME/webapps/$APP_DST_NAME

sh $TOMCAT_HOME/bin/startup.sh


