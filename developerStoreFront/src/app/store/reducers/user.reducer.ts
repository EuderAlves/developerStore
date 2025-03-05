import { createReducer, on } from '@ngrx/store';
import { setUser } from '../actions/user.actions';

export interface UserState {
  user: any;
}

export const initialState: UserState = {
  user: null,
};

export const userReducer = createReducer(
  initialState,
  on(setUser, (state, { user }) => ({ ...state, user }))
);
