import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import {
  setUser,
  clearUser,
  setUserHistory,
  setItems,
} from 'src/app/store/actions/user.actions';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(
    private store: Store<{
      user: { user: any | null; history: any[]; items: any[] };
    }>
  ) {}

  setUser(user: any) {
    this.store.dispatch(setUser({ user }));
    console.log('Usuário salvo no store:', user); // Log para confirmar que o usuário foi salvo
  }

  clearUser() {
    this.store.dispatch(clearUser());
  }

  setUserHistory(history: any[]) {
    this.store.dispatch(setUserHistory({ history }));
    console.log('Histórico salvo no store:', history); // Log para confirmar que o histórico foi salvo
  }

  setItems(items: any[]) {
    this.store.dispatch(setItems({ items }));
    console.log('Itens salvos no store:', items); // Log para confirmar que os itens foram salvos
  }

  getUser(): Observable<any | null> {
    return this.store.select((state) => state.user.user); // Seleciona o usuário do store
  }

  getUserHistory(): Observable<any[]> {
    return this.store.select((state) => state.user.history); // Seleciona o histórico do store
  }

  getItems(): Observable<any[]> {
    return this.store.select((state) => state.user.items); // Seleciona os itens do store
  }
}
