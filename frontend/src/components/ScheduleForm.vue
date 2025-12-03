<template>
  <form class="card" @submit.prevent="submit">
    <h3>新增用药计划</h3>
    <input v-model="form.patientId" class="input" placeholder="患者ID" required />
    <input v-model="form.drugName" class="input" placeholder="药物名称" required />
    <input v-model="form.dosage" class="input" placeholder="剂量说明" required />
    <input v-model="form.schedule" class="input" placeholder="用药频次，例如 每日三次" required />
    <textarea v-model="form.notes" class="input" placeholder="备注"></textarea>
    <div class="flex">
      <button class="button" type="submit">提交</button>
      <button class="button secondary" type="button" @click="reset">重置</button>
    </div>
  </form>
</template>

<script setup>
import { reactive } from 'vue';
import { usePatientsStore } from '../stores/usePatients';

const store = usePatientsStore();
const form = reactive({
  patientId: '',
  drugName: '',
  dosage: '',
  schedule: '',
  notes: ''
});

const submit = async () => {
  await store.createSchedule({ ...form });
  reset();
};

const reset = () => {
  form.patientId = '';
  form.drugName = '';
  form.dosage = '';
  form.schedule = '';
  form.notes = '';
};
</script>
