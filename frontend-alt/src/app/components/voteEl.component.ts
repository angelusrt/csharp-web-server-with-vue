import { Data } from '../api.service';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'vote-el',
  standalone: true,
  templateUrl: './voteEl.component.html',
  styleUrl: './voteEl.component.css'
})
export class VoteEl {
  @Input() votes: number = 0
  @Input() name: string = ''
  @Input() pseudonym: string = ''	
  @Input() postVote: Function = () => null

  public async post() {
    const data: Data = {pokemon: 0, pseudonym: ''}

    if (this.name === "squirtle") { data.pokemon = 1 }
    else if (this.name === "charmander") { data.pokemon = 2 }
    else { data.pokemon = 3 }

    data.pseudonym = this.pseudonym

    console.log(data)
    await this.postVote(data)
  }
}
