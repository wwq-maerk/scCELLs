import { defineStore } from 'pinia';
import apiClient from '../api/client';

export const usePatientsStore = defineStore('patients', {
  state: () => ({
    patients: [],
    schedules: [],
    loading: false,
    error: null
  }),
  actions: {
    async fetchPatients() {
      this.loading = true;
      try {
        const { data } = await apiClient.get('/api/patients');
        this.patients = data;
      } catch (err) {
        this.error = err;
      } finally {
        this.loading = false;
      }
    },
    async fetchSchedules(patientId) {
      this.loading = true;
      try {
        const { data } = await apiClient.get(`/api/patients/${patientId}/schedules`);
        this.schedules = data;
      } catch (err) {
        this.error = err;
      } finally {
        this.loading = false;
      }
    },
    async createSchedule(payload) {
      const { data } = await apiClient.post('/api/schedules', payload);
      this.schedules.push(data);
    }
  }
});
