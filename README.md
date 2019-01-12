You are expected to write a bet placement API that allows user to place a bet. Mock APIs have been provided to create bets and update user balance (see attachment).
 
The API will look like - 

`POST` /place-bet

**Headers**  
`Content-Type`: application/json

**Request**  
```
{
  "userId": "1",
  "stake": 20,
  "betId": "79967a8c-8d48-455e-9107-273a0546bf84" // GUID to be generated from client side
}
```

**Response**  
200 - if bet placement is successful
400 - if validation fails
```
{
  "reason": "insufficient balance"
}
```  
500 - if bet placement fails.
```
{
  "reason": "bet api unavailable"
}
```

Business rules:
1. Successful bet placement will create the bet and deduct the balance from user account
2. Bet cannot be placed if user doesn’t have enough balance
3. Unsuccessful bet placement (due to insufficient balance, bet API failure, etc) should not affect user balance


The bet placement API is to be written in C# preferably, but other languages are acceptable too.


Mock APIs can fail or time out. For best scalability, there will be multiple instances of bet placement API running. User may issue multiple bet placement calls concurrently. You may run shared services e.g. cache, queues or DB from Docker container.


Please try to come up with simple yet complete solution. You are not expected to handle all edge cases, but recommend to write up a document outlining design trade-offs and possible mitigations for edge cases. 


