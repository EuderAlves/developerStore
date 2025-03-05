import { createAction, props } from '@ngrx/store';

// Ação para setar o usuário
export const setUser = createAction('[User] Set User', props<{ user: any }>());

// Ação para limpar o usuário
export const clearUser = createAction('[User] Clear User');

// Ação para setar o histórico
export const setUserHistory = createAction(
  '[User] Set User History',
  props<{ history: any[] }>()
);

// Ação para setar os itens
export const setItems = createAction(
  '[Items] Set Items',
  props<{ items: any[] }>()
);
