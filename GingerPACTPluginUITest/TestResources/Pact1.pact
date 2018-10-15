Interaction: // Interaction Name
	Given "ffff"               
	Upon Receiving "cust 1"
		Method "Get"
		Path "/Customer/1"
		Headers:
			|Key|Value|
			|"Content-Type"|"application/json"|
		Body:
			{"param":"value", "param":"value"}	
	Will Respond With
		Status "200"
		Headers:
			|Key|Value|
			|"Content-Type"|"application/json"|
		Body:
			{"ID": "1"}