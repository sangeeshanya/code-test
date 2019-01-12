# Mock APIs for Pointsbet interview

## Get started
For local development, run `npm i` then `npm start`. 

Alternatively build the container in docker (see Dockerfile).

## API Definition

### Get user balance
`GET` /users/{id}
Get user balance. 10 users have been set up in the system, with id 1 - 10.

**Parameters**  
id: string, user Id

**Response**  
200 - OK  
```
{
  "balance": 100
}
```

404 - Not Found

### Update user balance
`POST` /users/{id}
Update user balance. 

**Headers**  
`Content-Type`: application/json

**Parameters**  
id: string, user Id
balance: number, account balance

**Request**  
```
{
  "balance": 200
}
```

**Response**  
200 - OK
400 - Bad Request  
404 - Not Found  
500 - Internal Server Error  

### Get bet details
`GET` /bets/{id}
Get bet details. 10 users have been set up in the system, with id 1 - 10.

**Parameters**  
id: string, bet Id

**Response**  
200 - OK  
```
{
  "userId": "1",
  "stake": 100
}
```

404 - Not Found

### Create bet
`POST` /bets/{id}
Create a bet. If the bet is placed with the same id, it will be replaced.

**Headers**  
`Content-Type`: application/json

**Parameters**  
id: string, client generated bet Id
userId: string, user Id,
stake: number, stake of the bet

**Request**  
```
{
  "userId": "1",
  "stake": 100
}
```

**Response**  
200 - OK
400 - Bad Request  
404 - Not Found  
500 - Internal Server Error