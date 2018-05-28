int M1 =3;
int M2 =5;
int M3 =6;
int M4 =9;
int LED =6;

void setup() {
  Serial.begin(9600);
  while(!Serial);
  
  pinMode(M1, OUTPUT);
  pinMode(M2, OUTPUT);
  pinMode(M3, OUTPUT);
  pinMode(M4, OUTPUT);
  pinMode(LED, OUTPUT);

}

void loop() {

   if (Serial.available() > 0)
   {
    char serialData = Serial.read();
    
    if(serialData =='N'){
        digitalWrite(M1,HIGH);

        ///////LED
        digitalWrite(LED, HIGH);
        delay(500);
        digitalWrite(LED, LOW);
        delay(500);
      }
      else if(serialData =='E'){
        digitalWrite(M2,HIGH);

        ///////LED
        digitalWrite(LED, HIGH);
        delay(500);
        digitalWrite(LED, LOW);
        delay(500);
      }
      else if(serialData =='W'){
        digitalWrite(M3,HIGH);

        ///////LED
        digitalWrite(LED, HIGH);
        delay(500);
        digitalWrite(LED, LOW);
        delay(500);
      }
      else if(serialData =='X'){
        digitalWrite(M4,HIGH);
        
        ///////LED
        digitalWrite(LED, HIGH);
        delay(500);
        digitalWrite(LED, LOW);
        delay(500);
      }
    }
}
