#include <dht.h>
#define sensorvcc 2
const int pinoSensorInfra = 8; //PINO DIGITAL UTILIZADO PELO SENSOR
const int pinoSensorAgua = A0; //PINO ANALÓGICO UTILIZADO PELO SENSOR
const int pinoDHT11 = A2;
const int pinoSensorTensao = A1;
int val = 0;
float tensaoEntrada = 0.0; //VARIÁVEL PARA ARMAZENAR O VALOR DE TENSÃO DE ENTRADA DO SENSOR
float tensaoMedida = 0.0; //VARIÁVEL PARA ARMAZENAR O VALOR DA TENSÃO MEDIDA PELO SENSOR

float valorR1 = 30000.0; //VALOR DO RESISTOR 1 DO DIVISOR DE TENSÃO
float valorR2 = 7500.0; // VALOR DO RESISTOR 2 DO DIVISOR DE TENSÃO
int leituraSensor = 0; //VARIÁVEL PARA ARMAZENAR A LEITURA DO PINO ANALÓGICO
dht DHT;





void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(pinoSensorInfra, INPUT); //DEFINE O PINO COMO ENTRADA
  pinMode(pinoSensorAgua, INPUT); //DEFINE O PINO COMO ENTRADA
  pinMode(pinoSensorTensao, INPUT); //DEFINE O PINO COMO ENTRADA
  pinMode(sensorvcc, OUTPUT);
  digitalWrite(sensorvcc, LOW);

}

void loop() {
  delay(1000);
  // put your main code here, to run repeatedly:
  int level = readSensor(); 
  leituraSensor = analogRead(pinoSensorTensao); //FAZ A LEITURA DO PINO ANALÓGICO E ARMAZENA NA VARIÁVEL O VALOR LIDO
   tensaoEntrada = (leituraSensor * 5.0) / 1024.0; //VARIÁVEL RECEBE O RESULTADO DO CÁLCULO
   tensaoMedida = tensaoEntrada / (valorR2/(valorR1+valorR2)); //VARIÁVEL RECEBE O VALOR DE TENSÃO DC MEDIDA PELO SENSOR

  Serial.println(DHT.temperature, 0);
  Serial.println(tensaoMedida,2);
  Serial.println(digitalRead(pinoSensorInfra));
  Serial.println(level);


}
int readSensor() {  
digitalWrite(sensorvcc, HIGH);  /* alimenta o sensor */
delay(10);              /* espera 10ms */
val = analogRead(pinoSensorAgua);    /* Realiza a leitura analógica do sinal do sensor */
digitalWrite(sensorvcc, LOW);   /* Desliga o sensor */
return val;             /* envia leitura */
}