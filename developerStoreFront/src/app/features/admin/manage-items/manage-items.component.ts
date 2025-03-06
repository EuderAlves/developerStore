import { Component, OnInit } from '@angular/core';
import { ItemService } from 'src/app/core/services/item.service'; // Importe o ItemService
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-manage-items',
  templateUrl: './manage-items.component.html',
  styleUrls: ['./manage-items.component.scss'],
})
export class ManageItemsComponent implements OnInit {
  items$: Observable<any[]>;
  urlImg: string =
    'https://www.ambev.com.br/sites/g/files/wnfebl10941/files/styles/webp/public/';

  constructor(
    private itemService: ItemService,
    private router: Router,
    private snackBar: MatSnackBar
  ) {
    this.items$ = this.itemService.getAllItems();
  }

  ngOnInit(): void {}

  deleteItem(itemId: string): void {
    this.itemService.deleteItem(itemId).subscribe({
      next: () => {
        this.openSnackBar('Item deletado com sucesso!');
        setTimeout(() => (this.items$ = this.itemService.getAllItems()), 1000);
      },
      error: (err) => {
        console.error('Erro ao deletar item.', err);
      },
    });
  }

  editItem(itemId: string): void {
    this.router.navigate(['/edit-item', itemId]);
  }

  addItem(): void {
    this.router.navigate(['/add-item']);
  }

  openSnackBar(message: string) {
    this.snackBar.open(message, 'Fechar', {
      duration: 3000,
    });
  }

  goBack(): void {
    this.router.navigate(['/home']);
  }
}
