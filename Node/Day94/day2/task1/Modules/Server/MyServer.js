let {FlightTicket} = require("../Modules/MyModule");
let ticket0 = new FlightTicket(1, 'A1', 'Nm', 'Fd', 'LO', '2023-04-01');
let ticket1=new FlightTicket(2,'A1', 'ABC123', 'NoN', 'Ale', '2022-04-01');
let ticket2=new FlightTicket(3,'A2', 'ABC153', 'RoR', 'Mar', '2023-04-01');
let ticket3= new FlightTicket(4,'A3', 'ABC133', 'For', 'Nor', '2024-04-01');
let ticketEdit=new FlightTicket(5,'A4', 'ABC666', 'For', 'Nor', '2024-04-01');
FlightTicket.addTicket(ticket0);
FlightTicket.addTicket(ticket1);
FlightTicket.addTicket(ticket2);
FlightTicket.addTicket(ticket3);

let foundTicket = FlightTicket.getTicketById(1);
console.log(foundTicket);
FlightTicket.updateTicket(2, ticketEdit);
FlightTicket.updateTicket(1, { seatNum: 'B2' });
console.log(FlightTicket.ticketArray);


