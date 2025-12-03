<template>
  <div class="card" :key="patient.id">
    <div class="flex-between">
      <div>
        <h3>{{ patient.name }}</h3>
        <p class="badge">{{ patient.age }}岁 · {{ patient.gender }}</p>
      </div>
      <button class="button" @click="$emit('view', patient)">查看用药</button>
    </div>
  </div>
</template>

<script setup>
const props = defineProps({
  patient: {
    type: Object,
    required: true
  }
});
</script>
