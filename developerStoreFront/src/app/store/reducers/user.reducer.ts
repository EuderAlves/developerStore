import { createReducer, on } from '@ngrx/store';
import {
  setUser,
  clearUser,
  setUserHistory,
  setItems,
} from '../actions/user.actions';

export interface UserState {
  user: any | null;
  history: any[];
  items: any[];
}

export const initialState: UserState = {
  user: null,
  history: [],
  items: [],
};

export const userReducer = createReducer(
  initialState,
  on(setUser, (state, { user }) => ({ ...state, user })),
  on(clearUser, (state) => ({ ...state, user: null })), // Limpa o usuário
  on(setUserHistory, (state, { history }) => ({ ...state, history })),
  on(setItems, (state, { items }) => ({ ...state, items }))
);
