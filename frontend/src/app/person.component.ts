import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { ApiService } from './api.service';

@Component({
  selector: 'person',
  templateUrl: 'person.component.html'
})

export class PersonComponent {
  relationControl = new FormControl();
  relations: string[];
  filteredRelations: Observable<string[]>;

  occasionControl = new FormControl();
  occasions: string[];
  filteredOccasions: Observable<string[]>;

  interests: string[];

  person:any

  presents:string[];

  constructor(public api: ApiService) { 
    this.person = {
      firstName: "",
      lastName: "",
      age: "",
      sex: "",
      relation: "",
      occasion: "",
      interests: "",
      priceLevel: "",
      psycoType: ""
    }
  }

  ngOnInit() {
    this.getDropdownsValues();
  }

  private getDropdownsValues() {
    this.api.getRelations().subscribe(relations => {
      this.relations = JSON.parse(JSON.stringify(relations));
      this.filteredRelations = this.relationControl.valueChanges.pipe(
        startWith(''),
        map(value => this._filter(value, this.relations))
      );
    });

    this.api.getOccasions().subscribe(occasions => {
      this.occasions = JSON.parse(JSON.stringify(occasions));
      this.filteredOccasions = this.occasionControl.valueChanges.pipe(
        startWith(''),
        map(value => this._filter(value, this.occasions))
      );
    });

    this.api.getInterests().subscribe(interests => {
      this.interests = JSON.parse(JSON.stringify(interests));
    });
  }

  private _filter(value: string, values: string[]): string[] {
    const filterValue = value.toLowerCase();
    return values.filter(option => option.toLowerCase().indexOf(filterValue) === 0);
  }

  public predictPresents() {
    let personCopy = Object.assign({}, this.person);
    personCopy.interests = personCopy.interests.map(x => x).join(",");

    this.api.postPerson(personCopy).subscribe(res => {
      this.presents = JSON.parse(JSON.stringify(res));
    });
  }
}
