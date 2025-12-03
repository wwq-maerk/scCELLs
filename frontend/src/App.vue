<template>
  <div class="container">
    <header class="flex-between" style="margin-bottom: 16px;">
      <div>
        <h1>患者用药管理</h1>
        <p>面向微信小程序的前端示例，后端 API 由 .NET Core 提供</p>
      </div>
      <a class="button secondary" href="https://developer.weixin.qq.com/">微信小程序指引</a>
    </header>

    <section class="grid" style="display: grid; grid-template-columns: 2fr 1fr; gap: 16px;">
      <div>
        <div class="card flex-between" style="margin-bottom: 12px;">
          <div>
            <h3>患者列表</h3>
            <p>同步后台患者信息，点击查看用药计划</p>
          </div>
          <button class="button" @click="loadPatients" :disabled="store.loading">
            {{ store.loading ? '加载中...' : '刷新' }}
          </button>
        </div>
        <div style="display: grid; gap: 12px;">
          <PatientCard
            v-for="patient in store.patients"
            :key="patient.id"
            :patient="patient"
            @view="viewSchedules"
          />
        </div>
      </div>
      <div style="display: grid; gap: 12px;">
        <div class="card">
          <h3>用药计划</h3>
          <p v-if="store.schedules.length === 0">选择患者后展示用药计划。</p>
          <div v-for="item in store.schedules" :key="item.id" style="margin-bottom: 12px;">
            <div class="flex-between">
              <div>
                <strong>{{ item.drugName }}</strong>
                <p>{{ item.dosage }} · {{ item.schedule }}</p>
                <small>{{ item.notes }}</small>
              </div>
              <span class="badge">{{ item.nextDoseTime || '待安排' }}</span>
            </div>
            <hr />
          </div>
        </div>
        <ScheduleForm />
      </div>
    </section>
  </div>
</template>

<script setup>
import { onMounted } from 'vue';
import PatientCard from './components/PatientCard.vue';
import ScheduleForm from './components/ScheduleForm.vue';
import { usePatientsStore } from './stores/usePatients';

const store = usePatientsStore();

const loadPatients = () => store.fetchPatients();
const viewSchedules = (patient) => store.fetchSchedules(patient.id);

onMounted(() => {
  loadPatients();
});
</script>
