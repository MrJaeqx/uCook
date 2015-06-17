void Setup_Appliances(String applianceArray[])
{
  applianceArray[0] = "#0FP:ABSENT%";
  applianceArray[1] = "#1GP:ABSENT%";
  applianceArray[2] = "#2WK:ABSENT%";
  applianceArray[3] = "#3BL:ABSENT%";
  applianceArray[4] = "#4VW:ABSENT%"; 
  applianceArray[5] = "#5OV:ABSENT%";
  applianceArray[6] = "#6MW:ABSENT%";
  applianceArray[7] = "#7AK:ABSENT%";
  applianceArray[8] = "#8TI:ABSENT%";
  applianceArray[9] = "#9WS:ABSENT%";
}

void Send_ApplianceList(String applianceArray[])
{
  for(int i = 0; i < 10; i++)
  {
    Serial.println(applianceArray[i]);
  }
}
