import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const LoginForm: React.FC = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();

  const handleLogin = (e: React.FormEvent) => {
    e.preventDefault();
  
    if (email && password) {
      navigate('/dashboard'); 
    }
  };

  return (
    <div className='min-h-screen min-w-full flex items-center justify-center bg-gradient-to-br from-blue-100 via-white to-blue-200'>
      <form onSubmit={handleLogin} className="max-w-md mx-auto mt-20 p-6 bg-white shadow-md rounded-2xl space-y-5">
        <h2 className="text-2xl font-bold text-center">Logowanie</h2>
        <input
          type="email"
          placeholder="Email"
          className="w-full p-2 border rounded-xl"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
        <input
          type="password"
          placeholder="Hasło"
          className="w-full p-2 border rounded-xl"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
        <button
          type="submit"
          className="w-full bg-blue-500 hover:bg-blue-600 text-white p-2 rounded-xl transition"
        >
          Zaloguj się
        </button>
      </form>
    </div>
  );
};

export default LoginForm;
