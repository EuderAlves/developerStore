import { createAction, props } from '@ngrx/store';

export const setUser = createAction('[User] Set User', props<{ user: any }>());

export const clearUser = createAction('[User] Clear User');

export const setUserHistory = createAction(
  '[User] Set User History',
  props<{ history: any[] }>()
);

export const setItems = createAction(
  '[Items] Set Items',
  props<{ items: any[] }>()
);
