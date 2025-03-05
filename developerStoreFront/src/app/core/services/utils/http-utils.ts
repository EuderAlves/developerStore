export function getApiUrl(): string {
  debugger;
  const isProduction = window.location.hostname !== 'localhost';
  const baseUrl = isProduction
    ? 'https://developerstore.onrender.com/api'
    : 'http://localhost:5000/api';

  return baseUrl;
}
