
class FlightTicket {
    constructor(id, seatNum, flightNum, departureAirport, arrivalAirport, travelDate) {
      this.id = id;
      this.seatNum = seatNum;
      this.flightNum = flightNum;
      this.departureAirport = departureAirport;
      this.arrivalAirport = arrivalAirport;
      this.travelDate = travelDate;
    } 
    static ticketArray = [];

    static addTicket(ticket) {
        this.ticketArray.push(ticket);
    }

    static getTicketById(id) {
        return this.ticketArray.find(ticket => ticket.id === id);
    }

    static updateTicket(id, updates) {
        const ticketIndex = this.ticketArray.findIndex(ticket => ticket.id === id);
        if (ticketIndex === -1) {
        console.log('Ticket not found');
        return 
        }//...this.ticketArray[ticketIndex],
        this.ticketArray[ticketIndex] = {...this.ticketArray[ticketIndex], ...updates };
    }
}


module.exports = {
    FlightTicket
    
}