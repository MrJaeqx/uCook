void CAN_Receive()
{
  if (CAN_MSGAVAIL == CAN.checkReceive())           // check if data coming
  {
    unsigned char len = 0;
    unsigned char buf[8];
    char msg[8];

    CAN.readMsgBuf(&len, buf);    // read data,  len: data length, buf: data buf

    for (int i = 0; i < len; i++) // print the data
    {
      Serial.write(buf[i]);
      Serial.print(" ");

      msg[i] = buf[i];
    }
    Serial.println();

    String message(msg);
    if (message.endsWith(ini))
    {
      if (message.startsWith("0FP:"))
      {
        appliances[0] = "#0FP:PRESENT%";
      }
      if (message.startsWith("1GP:"))
      {
        appliances[1] = "#1GP:PRESENT%";
      }
      if (message.startsWith("2WK:"))
      {
        appliances[2] = "#2WK:PRESENT%";
      }
      if (message.startsWith("3BL:"))
      {
        appliances[3] = "#3BL:PRESENT%";
      }
      if (message.startsWith("4VW:"))
      {
        appliances[4] = "#4VW:PRESENT%";
      }
      if (message.startsWith("5OV:"))
      {
        appliances[5] = "#5OV:PRESENT%";
      }
      if (message.startsWith("6MW:"))
      {
        appliances[6] = "#6MW:PRESENT%";
      }
      if (message.startsWith("7AK:"))
      {
        appliances[7] = "#7AK:PRESENT%";
      }
      if (message.startsWith("8TI:"))
      {
        appliances[8] = "#8TI:PRESENT%";
      }
      if (message.startsWith("9WS:"))
      {
        appliances[9] = "#9WS:PRESENT%";
      }
      
      lastIniTime = millis();
    }

    if (message.endsWith(ack))
    {
      Serial.print('#');
      Serial.print(message);
      Serial.println('%');
    }
  }
}
