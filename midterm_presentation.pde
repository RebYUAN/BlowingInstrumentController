/**
 * Processing Sound Library, Example 1
 * 
 * Five sine waves are layered to construct a cluster of frequencies. 
 * This method is called additive synthesis. Use the mouse position 
 * inside the display window to detune the cluster.
 */

import processing.sound.*;
import processing.serial.*;
Serial port = new Serial(this,"COM3",57600);
String message="";
float pressure = 0;
float pressure0 = 0;
float sineVolume;
SinOsc sine;

void setup() {  
  size(640, 360);
  background(255);
 

  
  sine = new SinOsc(this);
  sine.set(500, 0, 0.0, 0);
  sine.play();
  float a = 0;
  for(int j=0;j<100;j++){
    if(port.available()>0){
      String temp = port.readString();
      for(int i=0;i<temp.length();i++){
        if(temp.charAt(i)=='\n'){
          println(message);
          if(message.length()==10){
            pressure0 += float(message);
            a+=1;
          }
          message="";
        }else{
          message += temp.charAt(i);
        }
      }
    }
  }
  
  pressure0 = pressure0/a;
  println("default:"+pressure0);
}

void draw() {
  if(port.available()>0){
    String temp = port.readString();
    for(int i=0;i<temp.length();i++){
      if(temp.charAt(i)=='\n'){
        println(message);
        pressure = float(message)-pressure0;
        message="";
      }else{
        message += temp.charAt(i);
      }
    }
    sineVolume = 0.00087336014* pressure -0.006780956;
    if(sineVolume<=0){
      sineVolume = 0;
    }else if(sineVolume>=1){
      sineVolume = 1;
    }
    sine.amp(sineVolume);
    println(sineVolume);
  }

}
  
