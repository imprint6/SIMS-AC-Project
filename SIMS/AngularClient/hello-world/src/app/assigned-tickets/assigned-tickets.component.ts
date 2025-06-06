import { Component, OnInit } from '@angular/core';
import { HttpClientModule, HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-assigned-tickets',
  standalone: true,
  imports: [CommonModule, MatTableModule, MatButtonModule, HttpClientModule],
  templateUrl: './assigned-tickets.component.html',
  styleUrls: ['./assigned-tickets.component.css'],
})
export class AssignedTicketsComponent implements OnInit {
  assignedTicketsdata: any[] = [];
  isLoading = true;
  isError = false;
  errorMessage: string = '';

  // Define the state enum mapping
  stateEnum: { [key: number]: string } = {
    1: 'OPEN',
    2: 'INPROGRESS',
    3: 'WAITING',
    4: 'CLOSED',
  };

  apiUrl = (window as any).__env?.WEB_API_URL;

  constructor(
    private http: HttpClient,
    private cookieService: CookieService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.fetchAssignedTickets();
  }

  // Fetch assigned tickets from the API
  fetchAssignedTickets() {
    const token = this.cookieService.get('accessToken');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`,
      'Content-Type': 'application/json',
    });

    this.http.get(`${this.apiUrl}/ticket/assigned`, { headers }).subscribe({
      next: (response: any) => {
        this.assignedTicketsdata = response; // Assign the response to the correct property
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Error fetching tickets', err);
        this.isError = true;
        this.errorMessage = 'Error fetching tickets. Please try again later.';
        this.isLoading = false;
      },
    });
  }

  // Get the string representation of the state based on the enum
  getStateString(state: number): string {
    return this.stateEnum[state] || 'Unknown';
  }

  // Navigate to the edit ticket page with the selected ticket's ID
  editTicket(ticketId: number) {
    this.router.navigate([`/ticket/edit/${ticketId}`]);
  }

  stopInstance(ticketId: number) {
    const token = this.cookieService.get('accessToken');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`,
      'Content-Type': 'application/json',
    });

    this.http.post(`${this.apiUrl}/ticket/stop/${ticketId}`, {}, { headers }).subscribe({
      next: (response: any) => {
        console.log('Ticket stopped successfully', response);
        this.fetchAssignedTickets(); // Refresh the list after stopping the ticket
      },
      error: (err) => {
        console.error('Error stopping ticket', err);
        this.isError = true;
        this.errorMessage = 'Error stopping ticket. Please try again later.';
      },
    });
  }
}
