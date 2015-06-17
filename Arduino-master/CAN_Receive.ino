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
    if(message.endsWith(ini))
    {
      Serial.print('#');
      Serial.print(message);
      Serial.println('%');
    }
    
    if(message.endsWith(ack))
    {
      Serial.print('#');
      Serial.print(message);
      Serial.println('%');
    }
  }
}
