'use client';

import { useState } from "react";
import axios from "axios";

interface StoredProduct {
  id: number;
  warehouseID: number;
  productID: number;
  quantity: number;
  minQuantity: number;
  lastUpdated: string;
}

export default function StoredProductsPage() {
  const [clientID, setClientID] = useState<string>("");
  const [warehouseID, setWarehouseID] = useState<string>("");
  const [data, setData] = useState<StoredProduct[] | null>(null);
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null);
  const [showModal, setShowModal] = useState<boolean>(false);
  const [selectedProduct, setSelectedProduct] = useState<number | null>(null);
  const [newQuantity, setNewQuantity] = useState<number>(0);
  const [isFetched, setIsFetched] = useState<boolean>(false);

  const fetchStoredProducts = async () => {
    if (!clientID || !warehouseID) {
      setError("Both clientID and warehouseID are required");
      return;
    }
    setLoading(true);
    setError(null);
    setData(null);

    try {
      const response = await axios.get("/api/storedProducts", {
        params: { clientID, warehouseID },
      });
      setData(response.data.model);
      setIsFetched(true);
    } catch (err: any) {
      setError(err.response?.data?.error || "Something went wrong");
    } finally {
      setLoading(false);
    }
  };

  const handleDelivery = async () => {
    if (selectedProduct === null || newQuantity <= 0) return;

    try {
      await axios.put(`/api/storedProductsChangingQuantity/${selectedProduct}`, {
        clientID,
        quantity: newQuantity,
      }, {
        headers: { "Content-Type": "application/json" },
      });
      
      fetchStoredProducts();
      setShowModal(false);
    } catch (err: any) {
      setError(err.response?.data?.error || "Failed to update quantity");
    }
  };

  return (
    <div className="p-4">
      <h1 className="text-xl font-bold">Stored Products</h1>
      <div className="my-4">
        <input
          type="text"
          placeholder="Client ID"
          value={clientID}
          onChange={(e) => setClientID(e.target.value)}
          className="border p-2 mr-2"
        />
        <input
          type="text"
          placeholder="Warehouse ID"
          value={warehouseID}
          onChange={(e) => setWarehouseID(e.target.value)}
          className="border p-2 mr-2"
        />
        <button onClick={fetchStoredProducts} className="bg-blue-500 text-white p-2">
          Fetch Data
        </button>
      </div>

      {loading && <p>Loading...</p>}
      {error && <p className="text-red-500">Error: {error}</p>}
      {data && (
        <table className="border-collapse border w-full">
          <thead>
            <tr>
              <th className="border p-2">Product ID</th>
              <th className="border p-2">Quantity</th>
              <th className="border p-2">Min Quantity</th>
              <th className="border p-2">Last Updated</th>
            </tr>
          </thead>
          <tbody>
            {data.map((item) => (
              <tr key={item.id}>
                <td className="border p-2">{item.productID}</td>
                <td className="border p-2">{item.quantity}</td>
                <td className="border p-2">{item.minQuantity}</td>
                <td className="border p-2">{new Date(item.lastUpdated).toLocaleDateString()}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}

      {isFetched && (
        <div className="text-center mt-4">
          <button onClick={() => setShowModal(true)} className="bg-green-500 text-white p-2">
            Dostawa
          </button>
        </div>
      )}

      {showModal && (
        <div className="fixed inset-0 flex items-center justify-center bg-gray-800 bg-opacity-50">
          <div className="bg-white p-4 rounded shadow-lg w-96">
            <h2 className="text-lg font-bold mb-2">Dodaj dostawę</h2>
            <select
              className="border p-2 w-full mb-2"
              onChange={(e) => setSelectedProduct(Number(e.target.value))}
            >
              <option value="">Wybierz produkt</option>
              {data?.map((item) => (
                <option key={item.id} value={item.id}>{`Produkt ${item.productID}`}</option>
              ))}
            </select>
            <p>Podaj ilość</p>
            <input
              type="number"
              placeholder="Nowa ilość"
              value={newQuantity}
              onChange={(e) => setNewQuantity(Number(e.target.value))}
              className="border p-2 w-full mb-2"
            />
            <div className="flex justify-between">
              <button onClick={() => setShowModal(false)} className="bg-red-500 text-white p-2">Anuluj</button>
              <button onClick={handleDelivery} className="bg-blue-500 text-white p-2">Zapisz</button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
}