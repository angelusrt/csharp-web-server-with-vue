import { Component, Input, OnInit } from "@angular/core";

@Component({
  selector: 'alert',
  standalone: true,
  templateUrl: './alert.component.html',
  styleUrl: './alert.component.css'
})
export class Alert implements OnInit {
  @Input() message: string = ''
  @Input() duration: number = 5000
  @Input() dismiss: Function = () => null

  ngOnInit() { this.scheduleDismiss() }
  executeDismiss() { this.dismiss(); }
  private scheduleDismiss() {
    if (this.duration > 0) { setTimeout(() => { this.dismiss() }, this.duration) }
  }
}
