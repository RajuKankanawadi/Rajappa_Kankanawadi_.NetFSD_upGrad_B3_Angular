import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-root',
  standalone: true,              // ✅ REQUIRED
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('FirstApp');
}